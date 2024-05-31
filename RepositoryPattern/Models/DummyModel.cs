using RepositoryPattern.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class DummyModel : IEntity
    {
        public Guid Id { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }
    }
}
