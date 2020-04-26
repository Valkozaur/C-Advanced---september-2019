namespace _1._Logger.Factories
{
    using System;

    using Models.Layouts;
    using Models.Layouts.Contracts;

    public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            ILayout layout;

            if (type == nameof(SimpleLayout))
            {
                layout = new SimpleLayout();
            }
            else if(type == nameof(XmlLayout))
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new ArgumentException("Invalid Layout type.");
            }

            return layout;
        }
    }
}
