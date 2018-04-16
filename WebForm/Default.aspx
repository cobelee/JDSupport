<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-laptop"></i>系统监控</h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="Default.aspx">Home</a></li>
                <li><i class="fa fa-laptop"></i>系统监控</li>
            </ol>
        </div>
    </div>

    <div class="row">

        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
            <div class="info-box red-bg">
                <i class="fa fa-thumbs-o-up"></i>
                <div class="count">8</div>
                <div class="title">客户公司</div>
            </div>
            <!--/.info-box-->
        </div>
        <!--/.col-->

        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
            <div class="info-box green-bg">
                <i class="fa fa-cubes"></i>
                <div class="count">5500</div>
                <div class="title">设备总数</div>
            </div>
            <!--/.info-box-->
        </div>
        <!--/.col-->

        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
            <div class="info-box blue-bg">
                <i class="fa fa-cloud-download"></i>
                <div class="count">12</div>
                <div class="title">维修工</div>
            </div>
            <!--/.info-box-->
        </div>
        <!--/.col-->

        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
            <div class="info-box magenta-bg">
                <i class="fa fa-shopping-cart"></i>
                <div class="count">259K</div>
                <div class="title">Purchased</div>
            </div>
            <!--/.info-box-->
        </div>
        <!--/.col-->

    </div>
    <!--/.row-->


    <div class="row">
        <div class="col-lg-6 col-md-12">
            <!--/col-->
            <div class=" col-lg-6 col-md-3">

                <div class="social-box facebook">
                    <%--<i class="fa fa-facebook"></i>--%>
                    <i class="fa">报修单</i>
                    <ul>
                        <li>
                            <strong>256k</strong>
                            <span>friends</span>
                        </li>
                        <li>
                            <strong>359</strong>
                            <span>feeds</span>
                        </li>
                    </ul>
                </div>
                <!--/social-box-->

            </div>
            <!--/col-->

            <div class="col-lg-6 col-md-3">

                <div class="social-box twitter">
                    <i class="fa">派工单</i>
                    <ul>
                        <li>
                            <strong>1562k</strong>
                            <span>followers</span>
                        </li>
                        <li>
                            <strong>2562</strong>
                            <span>tweets</span>
                        </li>
                    </ul>
                </div>
                <!--/social-box-->

            </div>
            <!--/col-->

            <div class="col-lg-6 col-md-3">

                <div class="social-box linkedin">
                    <i class="fa fa-linkedin"></i>
                    <ul>
                        <li>
                            <strong>8926</strong>
                            <span>contacts</span>
                        </li>
                        <li>
                            <strong>6253</strong>
                            <span>feeds</span>
                        </li>
                    </ul>
                </div>
                <!--/social-box-->

            </div>
            <!--/col-->

            <div class="col-lg-6 col-md-3">

                <div class="social-box google-plus">
                    <i class="fa fa-google-plus"></i>
                    <ul>
                        <li>
                            <strong>962</strong>
                            <span>followers</span>
                        </li>
                        <li>
                            <strong>256</strong>
                            <span>circles</span>
                        </li>
                    </ul>
                </div>
                <!--/social-box-->

            </div>
            <!--/col-->
        </div>

        <div class="col-lg-6 col-md-12">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-spinner red"></i><strong>单据管理</strong></h2>
                    <div class="panel-actions">
                        <a href="index.html#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                        <a href="index.html#" class="btn-close"><i class="fa fa-times"></i></a>
                    </div>
                    <ul class="nav nav-tabs" id="recent">
                        <li class="active"><a href="index.html#tasks">Tasks</a></li>
                        <li><a href="index.html#tickets">Tickets</a></li>
                    </ul>
                </div>
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane active" id="tasks">
                            <table class="table bootstrap-datatable datatable small-font">
                                <thead>
                                    <tr>
                                        <th>Task</th>
                                        <th>Assigned to</th>
                                        <th>Progress</th>
                                        <th class="center">Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Package Usage</td>
                                        <td>Jenny Coe</td>
                                        <td>
                                            <div class="progress thin">
                                                <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="73" aria-valuemin="0" aria-valuemax="100" style="width: 73%">
                                                    <span class="sr-only">73% Complete (success)</span>
                                                </div>
                                            </div>
                                        </td>
                                        <td class="text-center text-info">Active
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Payment Process</td>
                                        <td>Jack Key</td>
                                        <td>
                                            <div class="progress thin">
                                                <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="95" aria-valuemin="0" aria-valuemax="100" style="width: 95%">
                                                    <span class="sr-only">95% Complete (success)</span>
                                                </div>
                                            </div>
                                        </td>
                                        <td class="text-center text-success">Active
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Web Development</td>
                                        <td>Jossy</td>
                                        <td>
                                            <div class="progress thin">
                                                <div class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="27" aria-valuemin="0" aria-valuemax="100" style="width: 27%">
                                                    <span class="sr-only">27% Complete (success)</span>
                                                </div>
                                            </div>
                                        </td>
                                        <td class="text-center text-warning">Pending
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Web Error</td>
                                        <td>Alex Bram</td>
                                        <td>
                                            <div class="progress thin">
                                                <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100" style="width: 50%">
                                                    <span class="sr-only">50% Complete (success)</span>
                                                </div>
                                            </div>
                                        </td>
                                        <td class="text-center text-primary">Active
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Storage Capacity</td>
                                        <td>Jimmy Doe</td>
                                        <td>
                                            <div class="progress thin">
                                                <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="73" aria-valuemin="0" aria-valuemax="100" style="width: 73%">
                                                    <span class="sr-only">73% Complete (success)</span>
                                                </div>
                                            </div>
                                        </td>
                                        <td class="text-center text-danger">Canceled
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Disk Performance</td>
                                        <td>Marcell</td>
                                        <td>
                                            <div class="progress thin">
                                                <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
                                                    <span class="sr-only">40% Complete (success)</span>
                                                </div>
                                            </div>
                                        </td>
                                        <td class="text-center text-primary">Active
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Yearly Services</td>
                                        <td>Morgan</td>
                                        <td>
                                            <div class="progress thin">
                                                <div class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="27" aria-valuemin="0" aria-valuemax="100" style="width: 27%">
                                                    <span class="sr-only">27% Complete (success)</span>
                                                </div>
                                            </div>
                                        </td>
                                        <td class="text-center text-warning">Pending
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="tab-pane" id="tickets">
                            <table class="table bootstrap-datatable datatable small-font">
                                <thead>
                                    <tr>
                                        <th>Status</th>
                                        <th>Date</th>
                                        <th>Description</th>
                                        <th>User</th>
                                        <th>Number</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><span class="label label-success">Complete</span></td>
                                        <td>May 10, 2014 18:05</td>
                                        <td>Disk problem</td>
                                        <td>Gerry</td>
                                        <td><b>[#26915]</b></td>
                                    </tr>
                                    <tr>
                                        <td><span class="label label-warning">Suspended</span></td>
                                        <td>May 10, 2014 18:05</td>
                                        <td>Hosting Update</td>
                                        <td>Sarah</td>
                                        <td><b>[#25986]</b></td>
                                    </tr>
                                    <tr>
                                        <td><span class="label label-danger">Rejected</span></td>
                                        <td>May 10, 2014 18:05</td>
                                        <td>Trouble Connection</td>
                                        <td>Smith</td>
                                        <td><b>[#23695]</b></td>
                                    </tr>
                                    <tr>
                                        <td><span class="label label-info">In progress</span></td>
                                        <td>May 10, 2014 18:05</td>
                                        <td>Domain Performance </td>
                                        <td>George</td>
                                        <td><b>[#24587]</b></td>
                                    </tr>
                                    <tr>
                                        <td><span class="label label-success">Complete</span></td>
                                        <td>May 10, 2014 18:05</td>
                                        <td>Paypal Registration</td>
                                        <td>Justin</td>
                                        <td><b>[#25698]</b></td>
                                    </tr>
                                    <tr>
                                        <td><span class="label label-success">Complete</span></td>
                                        <td>May 10, 2014 18:05</td>
                                        <td>Server Problem</td>
                                        <td>Elie</td>
                                        <td><b>[#25367]</b></td>
                                    </tr>
                                    <tr>
                                        <td><span class="label label-info">In progress</span></td>
                                        <td>May 10, 2014 18:05</td>
                                        <td>Design Error</td>
                                        <td>Reinald</td>
                                        <td><b>[#25639]</b></td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </div>


    </div>
    <!--/row-->
</asp:Content>

