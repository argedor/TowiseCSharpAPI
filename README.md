
# TOWISE C#/.NET API
Towise assists you to detect human faces and bodies with using the latest and reliable technology.

## Getting Started

### Installing
To install the package

```sh
nuget install towise 
```
To import your project
```csharp
using Towise;
```
### Using Towise
You must enter appKey and appId

For Example:
```csharp
using Towise;

namespace towise_example
{
    class Example
    {

    static void Main(string[] args)
        {

            String image  = "https://media.wmagazine.com/photos/5ac7d8f315242c3533df119f/4:3/w_1536/GettyImages-888922454.jpg";
            Towise p = new Towise("your appId","your appKey");

            //detects the face in the given image
            Console.WriteLine(p.faceDetect(image));

            //detects the bodies in the given image
            Console.WriteLine(p.bodyDetect(image));

            //recognizes the emotions in the given photograph
            Console.WriteLine(p.emotionDetect(image));

            //compares the face in the given image with the registered faces in the system
            Console.WriteLine(p.faceCompare(image));

            //gets all users on system
            Console.WriteLine(p.getAllPerson());

            //gets user that given id
            Console.WriteLine(p.getPerson("03a42fa2e1d1407b9388385efc01f083"));

            //adds a user that given name to the system
            Console.WriteLine(p.addPerson("keles0glu"));

            //removes the given user
            Console.WriteLine(p.removePerson("5605503de45744228471426ee9e2bf06"));

            //gets all faces of given user id 
            Console.WriteLine(p.getAllFace("7"));

            //gets base64 image of user face
            Console.WriteLine(p.getFace("9f9e2de584e24470a5ac786c9d4fc1c6"));

            //adds face to user
            Console.WriteLine(p.addFace(image,"7","yes"));

            //removes the face of given id
            Console.WriteLine(p.removeFace("9f9e2de584e24470a5ac786c9d4fc1c6"));

            Console.ReadKey();
        }
    }
}
```

## Versioning
For the versions available, see the https://github.com/argedor/TowiseCSharpAPI/tags

## Authors
* **Harun Keleşoğlu** - *Developer* - [Github](https://github.com/harunkelesoglu)
See also the list of [contributers](https://github.com/argedor/TowiseCSharpAPI/graphs/contributors)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details