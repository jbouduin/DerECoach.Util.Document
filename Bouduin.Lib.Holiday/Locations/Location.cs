using System.Collections.Generic;

namespace Bouduin.Lib.Holiday.Locations
{
    internal class Location: ILevel1Location
    {
        #region ILocation Members ---------------------------------------------
        public string Code { get; internal set; }
        
        public string Description { get; internal set; }
        public List<ILocation> Children { get; private set; }

        #endregion

        #region ILevel1Location members ----------------------------------------

        public string FileName { get; private set; }

        #endregion

        #region constructor ---------------------------------------------------
        internal Location(string fileName)
        {
            Children = new List<ILocation>();
            FileName = fileName;
        }

         
        #endregion
    }
}
