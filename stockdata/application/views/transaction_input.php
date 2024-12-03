<?php
defined('BASEPATH') OR exit('No direct script access allowed');
?>
        <main class="app-main"> <!--begin::App Content Header-->
            <div class="app-content-header"> <!--begin::Container-->
                <div class="container-fluid"> <!--begin::Row-->
                    <div class="row">
                        <div class="col-sm-6">
                            <h3 class="mb-0">Transaction Form</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-end">
                                <li class="breadcrumb-item"><a href="#">Transaction</a></li>
                                <li class="breadcrumb-item active" aria-current="page">
                                    New Transaction
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
                                    <div class="card-title">Detail item</div>
                                </div> <!--end::Header--> <!--begin::Form-->
                                <form action="<?php echo base_url() ?>pos/submit" method="post"> <!--begin::Body-->
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-8">
                                                <div class="mb-3">
                                                    <select class="d-none" id="itemgetter" name="itemgetter">
                                                        <?php foreach($item as $i) { ?>
                                                        <option value="<?php echo $i->id?>"><?php echo json_encode($i) ?></option>
                                                        <?php } ?>
                                                    </select>
                                                </div>
                                                <div class="mb-3"> <label for="selectitem" class="form-label">Select Item</label>
                                                    <select class="form-select" id="selectitem" name="selectitem" required>
                                                        <option selected disabled value="">Choose...</option>
                                                        <?php foreach($item as $i) { ?>
                                                        <option value="<?php echo $i->id?>"><?php echo $i->name?></option>
                                                        <?php } ?>
                                                    </select>
                                                </div>
                                                <div class="mb-3"> <label for="itemcategory" class="form-label">Category</label>
                                                    <input type="text" class="form-control" id="itemcategory" disabled>
                                                </div>
                                                <div class="mb-3"> <label for="itemprice" class="form-label">Item Price</label>
                                                    <input type="text" class="form-control" id="itemprice" disabled>
                                                </div>
                                                <div class="mb-3"> <label for="itememount" class="form-label">Amount</label>
                                                    <input type="number" class="form-control" id="itememount" name="itememount" aria-describedby="AmountHelp" value="0">
                                                    <div id="AmountHelp" class="form-text">
                                                        Please input numerical only.
                                                    </div>
                                                </div>
                                                <div class="mb-3"> <label for="itemtotal" class="form-label">Total</label>
                                                    <input type="text" class="form-control" id="itemtotal" disabled>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <img class="img-fluid object-fit-contain" id="itemImage" src="<?php echo base_url() ?>assets/img/item-blank.jpeg" alt="Item image">
                                            </div>
                                        </div>
                                        
                                    </div> <!--end::Body--> <!--begin::Footer-->
                                    <div class="card-footer">
                                        <button type="submit" class="btn btn-primary">Submit</button>
                                        <a href="<?php echo base_url() ?>pos" class="btn btn-warning" name="save" value="create">Cancel</a>
                                    </div> <!--end::Footer-->
                                </form> <!--end::Form-->
                            </div> <!--end::Quick Example-->
                        </div> <!--end::Col--> <!--begin::Col-->
                        
                    </div> <!--end::Row-->
                </div> <!--end::Container-->
            </div> <!--end::App Content-->
        </main> <!--end::App Main--> <!--begin::Footer-->