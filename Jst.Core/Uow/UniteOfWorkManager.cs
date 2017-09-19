using Jst.Core.Ioc;
using Jst.Core.JstException;
using Jst.UtilStandard;
using Jst.UtilStandard.Extension;
using System.Collections.Concurrent;

namespace Jst.Core.Uow
{
    public class UniteOfWorkManager : IUniteOfWorkManager,ISingleInstance
    {
        public const string JstCurrentUnitOfWorkKey = "Jst.Current.UnitOfWork";

        private static readonly ConcurrentDictionary<string, IUnitOfWork> UnitOfWorkDictionary = new ConcurrentDictionary<string, IUnitOfWork>();

        public IUnitOfWork Current
        {
            get { return GetCurrentUnitOfWork(); }
            private set { SetCurrentUnitOfWork(value); }
        }

        public IUnitOfWork GetUnitOfWork()
        {
            if (Current.IsNull())
            {
                Current = IocManager.Instance.Resolve<IUnitOfWork>();
            }
            return Current;
        }

        private IUnitOfWork GetCurrentUnitOfWork()
        {
            string unitOfWorkKey = string.Empty;
            // string unitOfWorkKey =   CallContext.LogicalGetData(JstCurrentUnitOfWorkKey) as string;
            if (unitOfWorkKey.IsEmpty())
            {
                return null;
            }
            IUnitOfWork unitOfWork;
            if (!UnitOfWorkDictionary.TryGetValue(unitOfWorkKey, out unitOfWork))
            {
                //logger.Warn("There is a unitOfWorkKey in CallContext but not in UnitOfWorkDictionary (on GetCurrentUow)! UnitOfWork key: " + unitOfWorkKey);
                //CallContext.FreeNamedDataSlot(JstCurrentUnitOfWorkKey);
                return null;
            }

            if (unitOfWork.IsDisposed)
            {
                UnitOfWorkDictionary.TryRemove(unitOfWorkKey, out unitOfWork);
               // CallContext.FreeNamedDataSlot(JstCurrentUnitOfWorkKey);
                return null;
            }

            return unitOfWork;
        }

        private void SetCurrentUnitOfWork(IUnitOfWork value)
        {
            if (value == null)
            {
                ExitFromCurrentUowScope();
                return;
            }
            string unitOfWorkKey = string.Empty;
            //var unitOfWorkKey = CallContext.LogicalGetData(JstCurrentUnitOfWorkKey) as string;
            if (unitOfWorkKey.IsNotEmpty())
            {
                IUnitOfWork outer;
                if (UnitOfWorkDictionary.TryGetValue(unitOfWorkKey, out outer))
                {
                    if (outer.Id == value.Id)
                    {
                        return;
                    }
                }
                else
                {
                    //logger.Warn("There is a unitOfWorkKey in CallContext but not in UnitOfWorkDictionary (on SetCurrentUow)! UnitOfWork key: " + unitOfWorkKey);
                }
            }

            unitOfWorkKey = value.Id;
            if (!UnitOfWorkDictionary.TryAdd(unitOfWorkKey, value))
            {
                throw new JstCoreException("Can not set unit of work! UnitOfWorkDictionary.TryAdd returns false!");
            }

            //CallContext.LogicalSetData(JstCurrentUnitOfWorkKey, unitOfWorkKey);
        }

        private static void ExitFromCurrentUowScope()
        {
            string unitOfWorkKey = string.Empty;
           // var unitOfWorkKey = CallContext.LogicalGetData(JstCurrentUnitOfWorkKey) as string;
            if (unitOfWorkKey == null)
            {
                return;
            }

            IUnitOfWork unitOfWork;
            if (!UnitOfWorkDictionary.TryGetValue(unitOfWorkKey, out unitOfWork))
            {
               // CallContext.FreeNamedDataSlot(JstCurrentUnitOfWorkKey);
                return;
            }

            UnitOfWorkDictionary.TryRemove(unitOfWorkKey, out unitOfWork);
        }
    }
}
