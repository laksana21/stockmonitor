<?php
defined('BASEPATH') OR exit('No direct script access allowed');
?>
        <main class="app-main"> <!--begin::App Content Header-->
            <div class="app-content-header"> <!--begin::Container-->
                <div class="container-fluid"> <!--begin::Row-->
                    <div class="row">
                        <div class="col-sm-6">
                            <h3 class="mb-0">New Item</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-end">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active" aria-current="page">
                                    New Item
                                </li>
                            </ol>
                        </div>
                    </div> <!--end::Row-->
                </div> <!--end::Container-->
            </div> <!--end::App Content Header--> <!--begin::App Content-->
            <div class="app-content"> <!--begin::Container-->
                <div class="container-fluid"> <!--begin::Row-->
                    <div class="row g-4"> <!--begin::Col-->

                        <div class="col-md-8"> <!--begin::Quick Example-->
                            <div class="card card-primary card-outline mb-4"> <!--begin::Header-->
                                <div class="card-header">
                                    <div class="card-title">Item Details</div>
                                </div> <!--end::Header--> <!--begin::Form-->
                                <form action="<?php echo base_url() ?>item/update" enctype="multipart/form-data" encoding='multipart/form-data' method='post'> <!--begin::Body-->
                                    <div class="card-body">
                                        <div class="d-none">
                                            <input type="text" class="form-control" name="categoryselect" id="categoryselect" value="<?php echo $item->category?>">
                                        </div>
                                        <div class="mb-3"> <label for="itemeditname" class="form-label">Item Name</label>
                                            <input type="text" class="form-control" name="itemeditname" id="itemeditname" value="<?php echo $item->name?>">
                                        </div>
                                        <div class="mb-3"> <label for="itemeditcategory" class="form-label">Select Category</label>
                                            <select class="form-select" id="itemeditcategory" name="itemeditcategory" required>
                                                <option selected disabled value="">Choose...</option>
                                                <?php foreach($category as $i) { ?>
                                                <option value="<?php echo $i->id?>"><?php echo $i->name?></option>
                                                <?php } ?>
                                            </select>
                                        </div>
                                        <div class="mb-3"> <label for="itemeditprice" class="form-label">Item Price</label>
                                            <input type="number" class="form-control" id="itemeditprice" name="itemeditprice" value="<?php echo $item->price?>">
                                        </div>
                                        <div class="mb-3"> <label for="itemeditamount" class="form-label">Base Stock</label>
                                            <input type="number" class="form-control" id="itemeditamount" name="itemeditamount" value="<?php echo $item->stock?>">
                                        </div>
                                        <div class="input-group mb-3">
                                            <input type="file" class="form-control" name="itemeditimage" id="itemeditimage">
                                            <label class="input-group-text" for="itemeditimage">Item Image</label>
                                        </div>
                                    </div> <!--end::Body--> <!--begin::Footer-->
                                    <div class="card-footer">
                                        <button type="submit" class="btn btn-primary">Submit</button>
                                        <a href="<?php echo base_url() ?>item" class="btn btn-warning" name="save" value="create">Cancel</a>
                                    </div> <!--end::Footer-->
                                </form> <!--end::Form-->
                            </div> <!--end::Quick Example-->
                        </div> <!--end::Col--> <!--begin::Col-->
                        <div class="col-md-4">
                            <img class="img-fluid object-fit-contain" id="itemImage" src="https://localhost:7147/resources/<?php echo $item->image?>" alt="Item image">
                        </div>
                        
                    </div> <!--end::Row-->
                </div> <!--end::Container-->
            </div> <!--end::App Content-->
        </main> <!--end::App Main--> <!--begin::Footer-->
