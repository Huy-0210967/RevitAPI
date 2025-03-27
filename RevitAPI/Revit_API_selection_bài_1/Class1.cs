using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI.Selection;
using System.CodeDom;

namespace Revit_API_selection_bài_1
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument idoc = commandData.Application.ActiveUIDocument;
            IList<Reference> referenceCollection = idoc.Selection.PickObjects(ObjectType.Face);
            HashSet<ElementId> selectedElements = new HashSet<ElementId>();

            foreach (Reference reference in referenceCollection)
            {
                selectedElements.Add(reference.ElementId);
            }
            MessageBox.Show("Bạn đã chọn " + referenceCollection.Count.ToString() + " mặt.");
            return Result.Succeeded;

        }
    }
}