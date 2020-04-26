
namespace _1._Logger.Models.Layouts
{
    using Layouts.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
