using Bouduin.Util.Document.Generic;

namespace Bouduin.Util.Document
{
    public static class Generator
    {
        public static IFactory NewFactory()
        {
            return new Factory();
        }
    }
}