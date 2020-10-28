import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-dept',
  templateUrl: './show-dept.component.html',
  styleUrls: ['./show-dept.component.css']
})
export class ShowDeptComponent implements OnInit {

  constructor(private service: SharedService) { }
  DepartmentList: any = [];
  

  ModalTitle: string;
  AcitvateAddEditDeptComponent:boolean = false;
  dep: any;

  DepartmentIdFilter: string="";
  DepartmentNameFilter: string="";

  DepartmentListWithoutFilter: any = [];

  ngOnInit(): void {
    this.refreshDeptList();
  }

  addClick() {
    this.dep = {
      DepartmentId: 0,
      DepartmentName:""
    }
    this.ModalTitle = "Add Department";
    this.AcitvateAddEditDeptComponent = true;
  }

  editClick(item) {
    this.dep = item;
    this.ModalTitle = "Edit Department";
    this.AcitvateAddEditDeptComponent = true;
  }

  deleteClick(item) {
    if (confirm('Are you sure you want to delete??')) {
      this.service.deleteDept(item.DepartmentId).subscribe(data => {
        
        alert(data.toString());
        this.refreshDeptList();
      })
      
    }
    
  }

  closeClick() {
    this.AcitvateAddEditDeptComponent = false;
    this.refreshDeptList();
  }

  refreshDeptList() {
    return this.service.getDeptList().subscribe(data => {
      this.DepartmentList = data;
      this.DepartmentListWithoutFilter = data;
    });
  }

  sortResult(prop, asc) {
    this.DepartmentList = this.DepartmentListWithoutFilter.sort(function (a,b) {
      if (asc) {
        return (a[prop] > b[prop] )? 1 : ((a[prop] < b[prop] )? -1 : 0);
      } else {
       return (b[prop] > a[prop ] )? 1 : ((b[prop] < a[prop]) ? -1 : 0);
      }
    })
  }

  FilterDept() {
    var DepartmentIdFilter = this.DepartmentIdFilter;
    var DepartmentNameFilter = this.DepartmentNameFilter;

    this.DepartmentList = this.DepartmentListWithoutFilter.filter(function (el) {
      return el.DepartmentId.toString().toLowerCase().includes(
        DepartmentIdFilter.toString().trim().toLowerCase()
      ) &&
        el.DepartmentName.toString().toLowerCase().includes(
          DepartmentNameFilter.toString().trim().toLowerCase()
        )
    });
  }
}
