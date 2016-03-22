using System;

namespace Core
{
	public interface IBitmapResizer<T>
	{
		T ResizeImageFromResources(object image,int width, int height);
	}
}