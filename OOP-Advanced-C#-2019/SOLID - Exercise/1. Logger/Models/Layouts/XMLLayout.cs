namespace _1._Logger.Models.Layouts
{
    using System.Text;

    using Layouts.Contracts;

    class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<log>");
                stringBuilder.AppendLine("\t<date>{0}</date>");
                stringBuilder.AppendLine("\t<level>{1}</level>");
                stringBuilder.AppendLine("\t<message>{2}</message>");
            stringBuilder.AppendLine("</log>");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
