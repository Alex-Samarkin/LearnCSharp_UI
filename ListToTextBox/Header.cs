using System.ComponentModel;

namespace ListToTextBox
{
    public class Header
    {
        [Category("Заголовок"), Description("Название колонки"), DefaultValue("Value")]
        [DisplayName("Название")]
        [NotifyParentProperty(true)]
        public string Name { get; set; } = "Value";

        [Category("Заголовок"), Description("Описание данных в колонке"), DefaultValue("Description")]
        [DisplayName("Описание")]
        [NotifyParentProperty(true)]
        public string Description { get; set; } = "Description";

        [Category("Заголовок"), Description("Комментарий к данным в колонке"), DefaultValue("Comment")]
        [DisplayName("Комментарий")]
        [NotifyParentProperty(true)]
        public string Comment { get; set; } = "Comment";



    }
}