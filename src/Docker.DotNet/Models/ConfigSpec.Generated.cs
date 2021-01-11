using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Docker.DotNet.Models
{
    [DataContract]
    public class ConfigSpec // (swarm.ConfigSpec)
    {
        public ConfigSpec()
        {
        }

        public ConfigSpec(Annotations Annotations)
        {
            if (Annotations != null)
            {
                this.Name = Annotations.Name;
                this.Labels = Annotations.Labels;
            }
        }

        [DataMember(Name = "Name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "Labels", EmitDefaultValue = false)]
        public IDictionary<string, string> Labels { get; set; }

        [DataMember(Name = "Data", EmitDefaultValue = false)]
        public string Data { get; set; }

        [DataMember(Name = "Templating", EmitDefaultValue = false)]
        public SwarmDriver Templating { get; set; }
    }
}
