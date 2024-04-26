import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PatientProviderDto, PatientService } from '@proxy/patients';
import { debounceTime, distinctUntilChanged, fromEvent, map, switchMap, tap } from 'rxjs';
import { GetPatientInput } from '@proxy/patients';
import { PagedResultDto } from '@abp/ng.core';
@Component({
  selector: 'app-my-patient',
  templateUrl: './my-patient.component.html',
  styleUrl: './my-patient.component.scss'
})
export class MyPatientComponent implements AfterViewInit {
  @ViewChild('search') search !: ElementRef ;
  title = 'type a head search';
  patientFilter = {} as GetPatientInput;
  patients = { items: [], totalCount: 0 } as PagedResultDto<PatientProviderDto>;
  state = false ;
  
  constructor(private service : PatientService ){}

  ngAfterViewInit(): void {
    fromEvent(this.search.nativeElement,'keyup').pipe(
      debounceTime(100),
      map((evt:any)=>evt.target.value),
      tap(()=>this.state = true) ,
      distinctUntilChanged(),
      switchMap((value:string)=>{
        if (value.length == 0) {
         this.state =false ;
         this.patients = { items: [], totalCount: 0 };
         return [];
        }
        return this.service.getAllPatientsOfProvider(this.patientFilter);
      }),
      tap(()=>this.state =false)
    ).subscribe((data:any)=> this.patients = data)
  }

  showDetailsOfPatient(rowId){

  }
}
