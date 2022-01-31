using Education_dotNet_Serialization_class;
using System.Runtime.Serialization.Formatters.Binary;

var order = new Order(4, 4.2m);

var bf = new BinaryFormatter();
using (var fs = new FileStream("serialized.dat", FileMode.Create))
{
    bf.Serialize(fs, order);
}

using (var fs = new FileStream("serialized.dat", FileMode.Open))
{
    var deserialized = (Order)bf.Deserialize(fs);
    var orderDeserialized = new Order(deserialized.Count, deserialized.Price);
    Console.WriteLine(orderDeserialized.TotalPrice);
}
