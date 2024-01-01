import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function customNumValidator(max: number, min: number): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const number = control.value;
    if (number === '') return null;
    if (number === 0) return { isZero: true };
    if (number > max || number < min) return { outOfRange: true };
    return null;
  };
}
