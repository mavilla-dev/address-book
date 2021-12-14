export const PersonUrl = "https://localhost:7037/api/Person";
export const AddressUrl = "https://localhost:7037/api/Address";
export const AddressUrlWithPerson = (personId: string) =>
  `https://localhost:7037/api/Address/${personId}`;
