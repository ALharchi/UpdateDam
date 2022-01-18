using System;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;


namespace UpdateDam
{
    public class UpdateDamComponent : GH_Component
    {
        public UpdateDamComponent() : base("UpdateDam", "UpdateDam", "This component doesn't update the solution flow until the value changes", "Params", "Util") 
        {
            UpdateOutput = true;
            PreviousData = "none";
        }
        protected override System.Drawing.Bitmap Icon { get { return Properties.Resources.iconUpdateDam; } }
        public override Guid ComponentGuid { get { return new Guid("72d3c7b4-0c68-48dc-877c-222842033708"); } }
        public override GH_Exposure Exposure { get { return GH_Exposure.primary; } }
        

        private bool UpdateOutput { get; set; }
        private string PreviousData { get; set; }

        protected override void ExpireDownStreamObjects()
        {
            if (UpdateOutput)
                Params.Output[0].ExpireSolution(false);
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Input", "In", "Data input.", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Output", "Out", "Data output.", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            DA.DisableGapLogic();

            string inputData = "";

            DA.GetData(0, ref inputData);
            DA.SetData(0, inputData);

            string currentData = inputData;

            if (UpdateOutput)
            {
                UpdateOutput = false;
                PreviousData = currentData;
                return;
            }

            if (!string.Equals(PreviousData, currentData))
            {
                UpdateOutput = true;
                PreviousData = currentData;

                var doc = OnPingDocument();
                doc?.ScheduleSolution(5, Callback);
            }

        }

        private void Callback(GH_Document doc)
        {
            if (UpdateOutput)
                ExpireSolution(false);
        }

    }
}

