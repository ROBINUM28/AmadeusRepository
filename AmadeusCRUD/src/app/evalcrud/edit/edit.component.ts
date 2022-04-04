import { Component, OnInit } from '@angular/core';
import { EvalcrudService } from '../evalcrud.services';
import { ActivatedRoute, Router } from '@angular/router';
import { Evalcrud } from '../evalcrud';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {

  id!: number;
  evalcrud!: Evalcrud;
  form!: FormGroup;

  constructor(
    public evalcrudService: EvalcrudService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.evalcrudService.find(this.id).subscribe((data: Evalcrud)=>{
      this.evalcrud = data;
      console.log(data);
    });

    this.form = new FormGroup({
      id: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
      observations: new FormControl('', Validators.required),
      startDate: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      nacionality: new FormControl('', Validators.required),
      active: new FormControl('', Validators.required)
    });
  }

  get f(){
    return this.form.controls;
  }

  submit(){
    this.form.valueChanges.subscribe(value => {
      console.log(value);
    });
    console.log(this.form.value);
    this.evalcrudService.update(this.id, this.form.value).subscribe((res:any) => {
         console.log('Register updated successfully!');
         this.router.navigateByUrl('evalcrud/index');
    })
  }

}
