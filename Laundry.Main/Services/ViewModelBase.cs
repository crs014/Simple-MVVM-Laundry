using Laundry.Entity;

namespace Laundry.Main.Services
{
    public class ViewModelBase : ObjectBase
    {
        public virtual void LoadData() { }
        public virtual void SaveData() { }
        public virtual void RefreshData() { }

        protected void ToolbarButtonMethod(IToolBarMethod toolBarMethod)
        {
            toolBarMethod.DoAction();
        }
    }
}
