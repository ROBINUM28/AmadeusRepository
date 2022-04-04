import { Component, OnInit } from '@angular/core';
import { EvalcrudService } from '../evalcrud.services';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  form: FormGroup;

  constructor(
    public evalcrudService: EvalcrudService,
    private router: Router
  ) {
    this.form = new FormGroup({
      startDate: new FormControl('', Validators.required),
      observations: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      name: new FormControl('', Validators.required),
      active: new FormControl('', Validators.required),
      nacionality: new FormControl('', Validators.required)
    });

  }

  ngOnInit(): void {
  }

  get f(){
    return this.form.controls;
  }

  submit(){
    console.log(this.form.value);
    this.evalcrudService.create(this.form.value).subscribe(res => {
         console.log('Register created successfully!');
         this.router.navigateByUrl('evalcrud/index');
    })
  }

}


