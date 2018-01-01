Moon.component('my-component', {
  template: `<div>
        <div>
            <div>
                <h1>Join</h1>

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
                    <button class="btn btn-lg btn-primary" onclick="handleJoinAttempt()">Join</button>
				</div><br />
                    <div><button class=" = btn btn-success" onclick="window.location.href='login.html'"> Sign in</button></div>
                
                <p id="error"></p>
            </div>
        </div>
        </div>`
});

const app1 = new Moon({
  el: "#app1"
});