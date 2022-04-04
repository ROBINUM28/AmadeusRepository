import { Component, OnInit } from '@angular/core';
import { EvalcrudService } from '../evalcrud.services';
import { ActivatedRoute, Router } from '@angular/router';
import { Evalcrud } from '../evalcrud';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss']
})
export class ViewComponent implements OnInit {

  id!: number;
  evalcrud!: Evalcrud;

 constructor(
    public evalcrudService: EvalcrudService,
    private route: ActivatedRoute,
    private router: Router
   ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    this.evalcrudService.find(this.id).subscribe((data: Evalcrud)=>{
      this.evalcrud = data;
    });
  }

}
