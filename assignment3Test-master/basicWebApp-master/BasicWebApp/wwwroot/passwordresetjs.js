Moon.component('my-component', {
  template: `<div class="container">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
                <h2>Reset Password</h2>

                <div class="form-group">
                    <input type="text" name="email" id="email" class="form-control" placeholder="Email" required autofocus/>
				</div>

                <div class="form-group">
                    <input type="password" name="password" id="password" class="form-control" placeholder="Password" required/>
				</div>

                <div class="form-group">
                    <input type="password" id="repeat_password" class="form-control" placeholder="Repeat Password" required/>
				</div>

                <div class="form-group">
                    <button class="btn btn-lg btn-primary" onclick="handleResetAttempt()">Reset Password</button>
				</div>
                
                <p id="error"></p>
            </div>
        </div>
        </div>`
});

const app3 = new Moon({
  el: "#app3"
});