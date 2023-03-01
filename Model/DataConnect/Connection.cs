using DocumentArchive.Model.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentArchive.Model.DataConnect
{
	internal class Connection
	{
		public static ElectronicDocumentArchiveEntities EDAEntities { get; set; }
	}
}
