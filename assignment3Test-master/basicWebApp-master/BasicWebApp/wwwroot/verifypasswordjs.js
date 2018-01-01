Moon.component('my-component', {
  template: `<div class="container">
        <div class="row">
            <div class="col-sm-6 col-sm-offset-3">
               
                <div class="form-group">
                  <button class=" = btn btn-success" onclick="window.location.href='login.html'"> Log In</button>
			        	</div>
            </div>
        </div>
        </div>`
});

const app6 = new Moon({
  el: "#app6"
});