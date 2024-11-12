using System;

namespace GalleryApp.Models
{
	public class Picture
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public double Size { get; set; }
		public DateTime CreateDate { get; set; }
		public string PicPath { get; set; }
		public Picture()
		{
			Id = Guid.NewGuid();
		}
	}
}