import { AddressDto } from "./AddressDto";

export type AddressListDto = {
  addresses: AddressDto[];
  personFirstName: string;
  personId: string;
  personLastName: string;
};
