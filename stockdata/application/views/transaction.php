<?php
defined('BASEPATH') OR exit('No direct script access allowed');
?>
        <main class="app-main"> <!--begin::App Content Header-->
            <div class="app-content-header"> <!--begin::Container-->
                <div class="container-fluid"> <!--begin::Row-->
                    <div class="row">
                        <div class="col-sm-6">
                            <h3 class="mb-0">Transaction List</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-end">
                                <li class="breadcrumb-item active" aria-current="page">
                                    Transaction
                                </li>
                            </ol>
                        </div>
                    </div> <!--end::Row-->
                </div> <!--end::Container-->
            </div> <!--end::App Content Header--> <!--begin::App Content-->
            <div class="app-content"> <!--begin::Container-->
                <div class="container-fluid"> <!--begin::Row-->
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card mb-4">
                                <div class="card-header">
                                    <div class="row">
                                        <div class="col-md-6 d-flex align-items-center">
                                            <h3 class="card-title">Latest Transaction List</h3>
                                        </div>
                                        <div class="col-md-6 d-flex justify-content-end">
                                            <a href="<?php echo base_url() ?>pos/input" class="btn btn-primary" name="save" value="create">Create New Transaction</a>
                                        </div>
                                    </div>
                                </div> <!-- /.card-header -->
                                <div class="card-body p-0">
                                    <table class="table table-striped">
                                        <thead>
                                            <tr>
                                                <th style="width: 10px">#</th>
                                                <th>Transact No</th>
                                                <th>Item Name</th>
                                                <th>Price</th>
                                                <th>Amount</th>
                                                <th>Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <?php $a = 1; foreach($item as $i) { ?>
                                            <tr class="align-middle">
                                                <td><?php echo $a ?>.</td>
                                                <td><?php echo $i->id ?></td>
                                                <td><?php echo $i->item ?></td>
                                                <td><?php echo $i->price ?></td>
                                                <td><?php echo $i->pcs ?></td>
                                                <td><?php echo number_format((float)$i->total, 2, '.', '') ?></td>
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