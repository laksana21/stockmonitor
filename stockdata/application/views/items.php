<?php
defined('BASEPATH') OR exit('No direct script access allowed');
?>
        <main class="app-main"> <!--begin::App Content Header-->
            <div class="app-content-header"> <!--begin::Container-->
                <div class="container-fluid"> <!--begin::Row-->
                    <div class="row">
                        <div class="col-sm-6">
                            <h3 class="mb-0">Item Management</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-end">
                                <li class="breadcrumb-item active" aria-current="page">
                                    Item
                                </li>
                            </ol>
                        </div>
                    </div> <!--end::Row-->
                </div> <!--end::Container-->
            </div> <!--end::App Content Header--> <!--begin::App Content-->
            <div class="app-content"> <!--begin::Container-->
                <div class="container-fluid"> <!--begin::Row-->
                    <div class="row">
                        <div class="col-md-9">
                            <div class="card mb-4">
                                <div class="card-header">
                                    <div class="row">
                                        <div class="col-md-6 d-flex align-items-center">
                                            <h3 class="card-title">Item List</h3>
                                        </div>
                                        <div class="col-md-6 d-flex justify-content-end">
                                            <a href="<?php echo base_url() ?>item/input" class="btn btn-primary" name="save" value="create">Add New Item</a>
                                        </div>
                                    </div>
                                </div> <!-- /.card-header -->
                                <div class="card-body p-0">
                                    <table class="table table-striped">
                                        <thead>
                                            <tr>
                                                <th style="width: 10px">#</th>
                                                <th>Item Name</th>
                                                <th>Price</th>
                                                <th>Category</th>
                                                <th style="width: 150px">Image</th>
                                                <th style="width: 100px">Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <?php $a = 1; foreach($item as $i) { ?>
                                            <tr class="align-middle">
                                                <td><?php echo $a ?>.</td>
                                                <td><?php echo $i->name ?></td>
                                                <td><?php echo $i->price ?></td>
                                                <td><?php echo $i->category ?></td>
                                                <td><img class="img-fluid" id="itemImage" src="https://localhost:7147/resources/<?php echo $i->image ?>" alt="Item image"></td>
                                                <td><a href="<?php echo base_url() ?>item/edit/<?php echo $i->id ?>" class="btn btn-primary" name="save" value="create">Edit Item</a></td>
                                            </tr>
                                            <?php $a++; } ?>
                                        </tbody>
                                    </table>
                                </div> <!-- /.card-body -->
                            </div> <!-- /.card -->
                        </div> <!-- /.col -->
                        <div class="col-md-3">
                            <div class="card mb-4">
                                <div class="card-header">
                                    <h3 class="card-title">Category List</h3>
                                </div> <!-- /.card-header -->
                                <div class="card-body p-0">
                                    <table class="table table-striped">
                                        <thead>
                                            <tr>
                                                <th style="width: 10px">#</th>
                                                <th>Category Name</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <?php $a = 1; foreach($category as $i) { ?>
                                            <tr class="align-middle">
                                                <td><?php echo $a ?>.</td>
                                                <td><?php echo $i->name ?></td>
                                            </tr>
                                            <?php $a++; } ?>
                                        </tbody>
                                    </table>
                                </div> <!-- /.card-body -->
                            </div> <!-- /.card -->
                        </div> <!-- /.col -->
                    </div> <!--end::Row-->
                </div> <!--end::Container-->
            </div> <!--end::App Content-->
        </main> <!--end::App Main--> <!--begin::Footer-->