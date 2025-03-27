using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;

namespace A005_TaoListElements
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
            TaskDialog.Show("Revit", "So luong doi tuong da chon: " + selectedIds.Count.ToString());
            ICollection<ElementId> selectedWallIds = new List<ElementId>();
            foreach (ElementId id in selectedIds)
            {
                Element elements1 = uidoc.Document.GetElement(id);
                if (elements1 is Wall)
                {
                    selectedWallIds.Add(id);
                }
            }
            uidoc.Selection.SetElementIds(selectedWallIds);
            if (0 != selectedWallIds.Count)
            {
                TaskDialog.Show("Revit", selectedWallIds.Count.ToString() + " Doi tuong tuong da duoc chon!");
            }
            else
            {
                TaskDialog.Show("Revit", "Khong co doi tuong tuong nao duoc chon");
            }
            return Result.Succeeded;
        }
    }
}
