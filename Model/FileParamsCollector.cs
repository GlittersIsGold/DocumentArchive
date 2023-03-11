using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentArchive.Model
{
	internal class FileParamsCollector
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public decimal Size { get; set; }

		public DateTime Created { get; set; }

		public byte[] Expression { get; set; }

		public int CategoryId { get; set; }
    }
}
