Moon.component('my-component', {
  template: `<div class="container">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                <h2>Sign In</h2>
                <div class="form-group">
                    <input type="text" name="email" id="email" class="form-control" placeholder="Email" required autofocus />
                </div>
                <div class="form-group">
                    <input type="password" name="password" id="password" class="form-control" placeholder="Password" required />
                </div>
                <div class="form-group">
                    <button class="btn btn-lg btn-primary" onclick="handleLoginAttempt()">Sign In</button>
                </div><br />
                <div><button class=" = btn btn-success" onclick="window.location.href='join.html'"> Create New Account</button></div>
                <br />
                <div><button class=" = btn btn-success" onclick="window.location.href='passwordreset.html'"> Forgot Password </button></div>
                 
                <p id="error"></p>
            </div>
        </div>
    </div>`
});

const app2 = new Moon({
  el: "#app2"
});