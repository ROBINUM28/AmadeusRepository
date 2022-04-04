import { Component, NgModule, OnInit } from '@angular/core';
import { EvalcrudService } from '../evalcrud.services';
import { Evalcrud } from '../evalcrud';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})


export class IndexComponent implements OnInit {

  evalcruds: Evalcrud[] = [];

  constructor(public evalcrudService: EvalcrudService) {   }

  ngOnInit(): void {
     this.evalcrudService.getAll().subscribe((data: Evalcrud[])=>{
      this.evalcruds = data;
      console.log(this.evalcruds);
    })
  }

  deleteEvalcrud(id:number){
    this.evalcrudService.delete(id).subscribe(res => {
         this.evalcruds = this.evalcruds.filter(item => item.id !== id);
         console.log('Registro Borrado');
    })
  }

}
