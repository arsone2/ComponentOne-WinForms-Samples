ZipImages
------------------------------------------------------------------------
Retrieve images directly from a zip file.

The sample compresses several image files into a zip file, then allows you to select an image.
After the selection, the sample uses the C1ZipEntry.OpenReader method to retrieve a stream with the image data, and loads the image using the Image.FromStream method.

The sample show several types of images, including ico, jpg, gif, tiff, bmp, and jpg images.