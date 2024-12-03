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

                        <div class="col-md-12"> <!--begin::Quick Example-->
                            <div class="card card-primary card-outline mb-4"> <!--begin::Header-->
                                <div class="card-header">
                                    <div class="card-title">Item Details</div>
                                </div> <!--end::Header--> <!--begin::Form-->
                                <form action="<?php echo base_url() ?>item/save" enctype="multipart/form-data" encoding='multipart/form-data' method='post'> <!--begin::Body-->
                                    <div class="card-body">
                                        <div class="mb-3"> <label for="itemname" class="form-label">Item Name</label>
                                            <input type="text" class="form-control" name="itemname" id="itemname">
                                        </div>
                                        <div class="mb-3"> <label for="itemcategory" class="form-label">Select Category</label>
                                            <select class="form-select" id="itemcategory" name="itemcategory" required>
                                                <option selected disabled value="">Choose...</option>
                                                <?php foreach($category as $i) { ?>
                                                <option value="<?php echo $i->id?>"><?php echo $i->name?></option>
                                                <?php } ?>
                                            </select>
                                        </div>
                                        <div class="mb-3"> <label for="itemprice" class="form-label">Item Price</label>
                                            <input type="number" class="form-control" id="itemprice" name="itemprice" value="0">
                                        </div>
                                        <div class="mb-3"> <label for="itememount" class="form-label">Base Stock</label>
                                            <input type="number" class="form-control" id="itememount" name="itememount" value="0">
                                        </div>
                                        <div class="input-group mb-3">
                                            <input type="file" class="form-control" name="itemimage" id="itemimage">
                                            <label class="input-group-text" for="itemimage">Item Image</label>
                                        </div>
                                    </div> <!--end::Body--> <!--begin::Footer-->
                                    <div class="card-footer"> <button type="submit" class="btn btn-primary">Submit</button> </div> <!--end::Footer-->
                                </form> <!--end::Form-->
                            </div> <!--end::Quick Example-->
                        </div> <!--end::Col--> <!--begin::Col-->
                        
                    </div> <!--end::Row-->
                </div> <!--end::Container-->
            </div> <!--end::App Content-->
        </main> <!--end::App Main--> <!--begin::Footer-->
