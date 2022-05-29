using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialog = OpenGroupsDialog();
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                }); ;
            }
      
            CloseGroupsDialog(dialog);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialog = OpenGroupsDialog();
            dialog.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialog(dialog);
        }

        public void Modify(GroupData oldData, GroupData newData)
        {
            Window dialog = OpenGroupsDialog();
            dialog.Get(SearchCriteria.ByText(oldData.Name)).Click();
            dialog.Get<Button>("uxEditAddressButton").Click();
            TextBox textBox = (TextBox)dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newData.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialog(dialog);
        }

        public void Remove(GroupData toBeRemoval)
        {
            Window dialog = OpenGroupsDialog();
            dialog.Get(SearchCriteria.ByText(toBeRemoval.Name)).Click();
            Window delDialog = OpenDeleteDialog();
            delDialog.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialog(dialog);
        }

        public void RemoveTheOnlyGroup(GroupData toBeRemoval)
        {
            Window dialog = OpenGroupsDialog();
            dialog.Get(SearchCriteria.ByText(toBeRemoval.Name)).Click();
            dialog.Get<Button>("uxDeleteAddressButton").Click();
            CloseInfoDialog();
            CloseGroupsDialog(dialog);
        }

        public void CloseGroupsDialog(Window dialog)
        {
            manager.MainWindow.Get<Button>("uxCloseAddressButton").Click();
        }

        public Window OpenGroupsDialog()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        public Window OpenDeleteDialog()
        {
            manager.MainWindow.Get<Button>("uxDeleteAddressButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE).ModalWindow(DELETEWINTITLE);
        }

        public void CloseInfoDialog()
        {
            manager.MainWindow.ModalWindow(GROUPWINTITLE).ModalWindow("Information");
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
        }
    }
}