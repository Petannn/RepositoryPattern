using RepositoryPattern.Abstraction;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Dto
{
    public class DummyDto : IDto
    {
        public Guid Id { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }
    }
}
