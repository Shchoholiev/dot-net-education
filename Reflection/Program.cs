using System.Reflection;

var assemblyInterface = Assembly.LoadFrom("Education_dotNet_Reflection_interface");
var interfaceType = assemblyInterface.GetTypes()
                                  .Where(t => t.Name == "IInterface")
                                  .FirstOrDefault();

var assemblyClasses = Assembly.LoadFrom("Education_dotNet_Reflection_classes");
var myClass = assemblyClasses.GetTypes()
                             .Where(c => interfaceType.IsAssignableFrom(c))
                             .FirstOrDefault();

var classInstance = assemblyClasses.CreateInstance(myClass.ToString());
classInstance?.GetType()?.GetProperty("CurrentIndex")?.SetValue(classInstance, 5);
Console.WriteLine(classInstance?.GetType()?.GetMethod("GetNextIndex")?.Invoke(classInstance, null));