using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace UpdateDam
{
    public class UpdateDamInfo : GH_AssemblyInfo
    {
        public override string Name { get { return "UpdateDam"; } }
        public override Bitmap Icon { get { return null; } }
        public override string Description { get { return "UpdateDam is one component plugin that block the flow in the solution until the input value changed."; } }
        public override Guid Id { get { return new Guid("45f14699-1090-4521-9a89-dac8460d474a"); } }
        public override string AuthorName { get { return "Ayoub Lharchi"; } }
        public override string AuthorContact { get { return "alha@kglakademi.dk"; } }
    }
}
