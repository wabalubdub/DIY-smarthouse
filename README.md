redesign:

# DIY Smarthouse

This project is an attempt to build a Do It Yourself smart-house out of of things i can build using simple electronics, 3D printing and software.

The idea is that micro-controllers are super cheap and that using a local LAN network you can make little devices that could communicate with each other and with you in a very simple way. I like it because its fun and because using micro-controlers on to of existing hardware in and around the house is slightly less invasive then getting in of the shelf solution.

for example i can use a servo to turn on my light switch instead of using a relay in the light switch's actual mechanism:

![Image of a smart lightswitch][/images/lightswitch addon with servo.jpeg]

the micro-controller would be connected to my local WIFI in the house and get HTTP requests from any source.

# design

The build I'm planning on implementing is as follows:

- Model - my model will be built as a configurable JSON file that contains all the appliances in my house, each one will have a description a name an IP and some information about how one interacts with it and some information for the view in order to customize the way a UI would view the Model.

- view - in order to implement the frontend of my smart house I will use an ASP.NET application built with Blazor pages. the pages will be customized based on configuration and new views will adapt to new needs in the model.

- controller - controllers will be responsible for interacting with the model and sending the correct messages to the right place. the controllers will use the command pattern in order to create custom requests that might even need to change in runtime. plus using the command pattern will make using macro commands easy in order to make settings like movie get ready for bed or turn everything off.

- Micro-controllers - the code on the micro-controllers is a little harder to make generic, as it is an embedded device the deployment and the customization is very particular, iI will post all the code I'm deploying with pictures and examples but if you want to recreate this you might need to change things in that area.
