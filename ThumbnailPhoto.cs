using Microsoft.Azure.ActiveDirectory.GraphClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureADGraphTest
{
    class ThumbnailPhoto
    {
        public static async void Run()
        {
            string userObjectID = "fe989a2b-81d1-48ca-aa15-0ac52688f65b";

            ActiveDirectoryClient activeDirectoryClient = GraphHelper.CreateGraphClient();
            var res = await activeDirectoryClient.Users
                .Where(u => u.ObjectId.Equals(userObjectID)).ExecuteAsync();
            IUser user = res.CurrentPage.ToList().First();

            var image = await user.ThumbnailPhoto.DownloadAsync();
        }

        public static async void Update()
        {

            ActiveDirectoryClient activeDirectoryClient = GraphHelper.CreateGraphClient();
            IUser user =await activeDirectoryClient.Me.ExecuteAsync();
           
            FileStream photoStream = File.Open(@"C:\Users\v-fexue\Desktop\me.jpg", FileMode.Open);
            await user.ThumbnailPhoto.UploadAsync(photoStream, "image/Jpeg");
            photoStream.Close();

        }

        public static void EncodeImage()
        {
            string base64image = "/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAIBAQIBAQICAgICAgICAwUDAwMDAwYEBAMFBwYHBwcGBwcICQsJCAgKCAcHCg0KCgsMDAwMBwkODw0MDgsMDAz/2wBDAQICAgMDAwYDAwYMCAcIDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAz/wAARCABZAFoDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9/KKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigDyv8AbS+OGrfs5fs46/4v0S30+61LSzAIor6N3gbfMkZ3BGRujHGGHOK888FeK/2pPHfg3SdctE+AUdprNlDfQJMNXEipKiuoYAkBsMM4JGe5rR/4Kof8mN+Mfraf+lUVc38Ff26v+Ec+DfhLT/8AhTnx3vvsOjWdv9ps/Cfm29xsgRd8b+aNyNjKnHIINeE60Xiq0K1RpR5LJealfp5I+BzzHxhnkcNiK86dP2KlaLavL2kl0T6H0r4H/tv/AIRDTv8AhJP7L/t7yF+3/wBmeZ9j87HzeV5nz7M9N3NatVdE1P8AtvRrS8+z3Vp9rhSbyLmPy5odyg7HX+FhnBHYg1ar3ndOzPucPZUo8rbVlq935vzCiiikahRRRQAUUUUAFFFFAHzz/wAFUP8Akxvxj9bT/wBKoq9T/Zy/5N68B/8AYu6f/wCk0ddF4q8I6T460ObTNb0vT9Y024x5tpfWyXEEuCGG5HBU4IBGR1Aq1pum2+jadBaWkENraWsawwQQoEjhRQAqqo4CgAAAcACuWhh3TrVqrfx8ny5VJfqeN/Zkv7X/ALS5tPZezt1vzuV/xsT0UUV1HshRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAf/Z";
            Console.WriteLine(base64image);
            Console.WriteLine("");
            string base64imageByCode = Convert.ToBase64String(File.ReadAllBytes(@"C:\Users\v-fexue\Desktop\me.jpg"));
            Console.WriteLine(base64imageByCode);
            Console.WriteLine("");
            Console.WriteLine(base64image==base64imageByCode);
        }

        public static void EncodeMyImage()
        {
            Console.WriteLine(Convert.ToBase64String(File.ReadAllBytes(@"C:\Users\v-fexue\Desktop\me1.jpg")));
            var data = "/9j/4AAQSkZJRgABAQEAYABgAAD/4QAiRXhpZgAATU0AKgAAAAgAAQESAAMAAAABAAEAAAAAAAD/2wBDAAIBAQIBAQICAgICAgICAwUDAwMDAwYEBAMFBwYHBwcGBwcICQsJCAgKCAcHCg0KCgsMDAwMBwkODw0MDgsMDAz/2wBDAQICAgMDAwYDAwYMCAcIDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAz/wAARCABZAFoDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9/KKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigCj4ovdQ03w3f3Gl2MWp6lBA8lrZy3H2dLqQAlYzJtbZuOBu2nGeleG/sqft+6P+0P4U8Y3ms6T/wheo+Bmd9UsZ737SYYFUky7vLToyOpXbwVHPIr6Ar8nf8AgogsN9+1N8SLj4cx6kbC302KPxq9qP8AR/MM0ayZ9vMEG7H8auegY18/nGYVsHOM4O6kpLl7NK6n35VtLW1mrK+p8TxpnWKyilRzGjLmjGVpU7L304u1nZtOLXNZNJx5m9j73/Yx/az1L9rzw9q+vf8ACHN4b8O2d0bSwu5dSNxJqLL94iPyUCqoK5IZvmJHOCa9rrz79lObwrP+zn4PbwThfDP9mxfY1yC68fOJMZ/eCTfv/wBvdXoNe9CnKEVCUuZpWb01fV6aK/ZdPvPc4dniJ5bRq4qqqk5RUnJJJe9rZWS0V7J7tK71YUUUVR7QUUUUAFFFFABRRRQBk+PNI1XX/BupWOh6rFoerXcDRW2oSWv2oWbHjzPL3puIGSAWAzgnI4Pjf7Lv7A+g/s9/CrxT4d1TUG8X3XjVpF1nULi28hruJlZRHt3uQBuc5LElnJ9APeqK5qmDozm6k43bi4u/8r1attr1e7Wl7Hn4jK8LXxNPF1o806d+W7dlzKz0vy3a0u1ex4j+xZ+yLqX7H2g6zoY8ZN4m8PX1z9rsrSbTPs8mnueGxIJWDhlC5G1RlcjGSD7dRRWtKnGnTjThtFWW70W2r1+8rLctw2X4eOEwkeWEb2V27Xd9Ltu13tsumgUUUVodwUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAf/2Q==";
            Console.WriteLine("");
            Console.WriteLine(data==Convert.ToBase64String(File.ReadAllBytes(@"C:\Users\v-fexue\Desktop\me1.jpg")));
            /*
             /9j/4AAQSkZJRgABAQEAYABgAAD/4QAiRXhpZgAATU0AKgAAAAgAAQESAAMAAAABAAEAAAAAAAD/2wBDAAIBAQIBAQICAgICAgICAwUDAwMDAwYEBAMFBwYHBwcGBwcICQsJCAgKCAcHCg0KCgsMDAwMBwkODw0MDgsMDAz/2wBDAQICAgMDAwYDAwYMCAcIDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAz/wAARCABZAFoDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9/KKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigCj4ovdQ03w3f3Gl2MWp6lBA8lrZy3H2dLqQAlYzJtbZuOBu2nGeleG/sqft+6P+0P4U8Y3ms6T/wheo+Bmd9UsZ737SYYFUky7vLToyOpXbwVHPIr6Ar8nf8AgogsN9+1N8SLj4cx6kbC302KPxq9qP8AR/MM0ayZ9vMEG7H8auegY18/nGYVsHOM4O6kpLl7NK6n35VtLW1mrK+p8TxpnWKyilRzGjLmjGVpU7L304u1nZtOLXNZNJx5m9j73/Yx/az1L9rzw9q+vf8ACHN4b8O2d0bSwu5dSNxJqLL94iPyUCqoK5IZvmJHOCa9rrz79lObwrP+zn4PbwThfDP9mxfY1yC68fOJMZ/eCTfv/wBvdXoNe9CnKEVCUuZpWb01fV6aK/ZdPvPc4dniJ5bRq4qqqk5RUnJJJe9rZWS0V7J7tK71YUUUVR7QUUUUAFFFFABRRRQBk+PNI1XX/BupWOh6rFoerXcDRW2oSWv2oWbHjzPL3puIGSAWAzgnI4Pjf7Lv7A+g/s9/CrxT4d1TUG8X3XjVpF1nULi28hruJlZRHt3uQBuc5LElnJ9APeqK5qmDozm6k43bi4u/8r1attr1e7Wl7Hn4jK8LXxNPF1o806d+W7dlzKz0vy3a0u1ex4j+xZ+yLqX7H2g6zoY8ZN4m8PX1z9rsrSbTPs8mnueGxIJWDhlC5G1RlcjGSD7dRRWtKnGnTjThtFWW70W2r1+8rLctw2X4eOEwkeWEb2V27Xd9Ltu13tsumgUUUVodwUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAf/2Q==
             */

        }
    }
}
