Moon.component('my-component', {
  template: `<div class="container">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                <h1>Sign in</h1>

                <div class="form-group">
                    <input type="text" name="email" id="email" class="form-control" placeholder="Email" required autofocus/>
				</div>

                <div class="form-group">
                    <input type="password" name="password" id="password" class="form-control" placeholder="Password" required/>
				</div>

                <div class="form-group">
                    <button class="btn btn-lg btn-primary" onclick="handleSigninAttempt()">Sign in</button>
				</div>
                
                <a href="/join" class="text-center">Create an account</a></br>
                <a href="/passwordreset" class="text-center">I forgot my password</a>
                <p id="error"></p>
            </div>
        </div>
        </div>`
});

const app5 = new Moon({
  el: "#app5"
});