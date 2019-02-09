namespace Assignment4.RefactorToFactory
{
    public class ShapeFactory
    {

        public Shape CreateShape(string type)
        {
            type = type.ToLower();
            Shape tempShape = null;
            if (type.Equals("rectangle"))
                tempShape = new Rectangle();
            else if (type.Equals("square"))
                tempShape = new Square();
            else if (type.Equals("circle"))
                tempShape = new Circle();
            else if (type.Equals("triangle"))
                tempShape = new Triangle();
            return tempShape;
        }
    }
}