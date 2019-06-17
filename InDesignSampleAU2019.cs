using System;
using InDesign;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

[Transaction(TransactionMode.Manual)]
public class InDesignSampleAU2019 : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        try
        {
            Type type = Type.GetTypeFromProgID("InDesign.Application");
            Application inDesignApp = (Application)Activator.CreateInstance(type);

            InDesign.Document inDesignDocument = inDesignApp.Documents.Add();

            //Create 5 new blank pages
            for (var i = 0; i < 5; i++) inDesignDocument.Pages.Add(idLocationOptions.idAtBeginning);

            return Result.Succeeded;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return Result.Failed;
        }
    }
}