Moon.component('my-component', {
  template: `<div class="container">
        <!-- Trigger the modal with a button -->
        <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add a Picture</button>

        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Add a Picture</h4>
                    </div>
                    <div class="modal-body">
                        <form method="post" enctype="multipart/form-data" asp-controller="Upload" action="Upload/post">
                            <div class="form-group">
                                <div class="col-md-10">
                                    <input type="file" name="files" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10">
                                    <input type="submit" value="Upload" />
                                </div>
                            </div>
                        </form>
                    </div>
                    
                </div>
            </div>
        </div>
        
      
        <!-- create a div with an id to give us an anchor point to let the javascript do its work -->
        <div id="posts"></div>
    </div>`
});

const app4 = new Moon({
  el: "#app4"
});