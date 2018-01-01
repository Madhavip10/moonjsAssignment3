 Moon.use(MoonRouter);

    // create a router with the two following routes:
    // set "/" route to use the "Home" component
    // set "/calculator" route to use the "Calculator" component
    const router = new MoonRouter({
        map: {
            "/": "Home",
            "/calculator": "Calculator"
        }
    });

    // create new instance of moon, work inside of #app
    // and pass in the router for Moon to use
    new Moon({
        el: "#app",
        router: router
    });
	
    Moon.component("Home", {
        template:
            `<div>
                 <h1>Home</h1>
                 <p>This is the homepage of your application! Check out the calculator!</p>
             </div>`
    });
   Moon.component("Calculator", {
        data: () => ({
            number1: 1,
            number2: 2
        }),
        template:
            `<div>
                 <h1>Calculator</h1>
                 <label>Number 1 </label>
                 <input type="number" m-model="number1">
                 +<label>Number 2</label>
                 <input type="number" m-model="number2">
                 =
                 <span>{{total}}</span>
             </div>`,
         computed: {
            total: {
                get: function() {
                  return +this.get("number1") + +this.get("number2");
                }
            }
        }
    });