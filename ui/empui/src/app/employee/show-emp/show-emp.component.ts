import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit {

  constructor(private service:SharedService) { }
  EmployeeList: any = [];

  ModalTitle: string;
  AcitvateAddEditEmpComponent: boolean = false;
  emp: any;


  ngOnInit(): void {
    this.refreshEmpList();
  }
  addClick() {
    this.emp = {
      EmployeeId: 0,
      EmployeeName: "",
      Department: "",
      DateOfJoining: "",
      PhotoFileName: "anonymous.png"
    } 
    this.ModalTitle = "Add Employee";
    this.AcitvateAddEditEmpComponent = true;
  }

  editClick(item) {
    this.emp = item;
    this.ModalTitle = "Edit Employee";
    this.AcitvateAddEditEmpComponent = true;
  }

  deleteClick(item) {
    if (confirm('Are you sure you want to delete??')) {
      this.service.deleteEmp(item.EmployeeId).subscribe(data => {

        alert(data.toString());
        this.refreshEmpList();
      })

    }

  }

  closeClick() {
    this.AcitvateAddEditEmpComponent = false;
    this.refreshEmpList();
  }

  refreshEmpList() {
    return this.service.getEmpList().subscribe(data => {
      this.EmployeeList = data;
    });
  }

}
