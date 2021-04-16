using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAVModule.Models
{
    public class ContentTypeDefinition
    {
        public ContentTypeDefinition() { }

        [Required]
        public string Name { get; set; }
        public bool Draftable { get; set; } = true;
        public bool Versionable { get; set; } = true;
        public bool Creatable { get; set; } = true;
        public bool Securable { get; set; } = true;
        public bool Listable { get; set; } = true;
        public List<ContentPartDefinition> ContentParts { get; set; }
    }

    public class ContentPartDefinition
    {
        public ContentPartDefinition() { }

        [Required]
        public string Name { get; set; }
        public List<ContentFieldDefinition> ContentFields { get; set; }
    }

    public class ContentFieldDefinition
    {
        public ContentFieldDefinition() { }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public dynamic Settings { get; set; } = null;
    }
}
