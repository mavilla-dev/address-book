import { createUseStyles } from "react-jss";
import { Link } from "react-router-dom";
import { AddressDto } from "server/AddressDto";
import { SiteTheme } from "./SiteTheme";

type Props = {
  personId: string;
  addresses: AddressDto[];
};
type Styles = "row" | "column";

const useStyles = createUseStyles<Styles, Props, SiteTheme>({
  column: {
    width: "16.667%",
  },
  row: {
    display: "flex",
  },
});

export default function AddressTable(props: Props) {
  const styles = useStyles();

  return (
    <>
      <div>
        <Link to={`/address/${props.personId}/new`}>Add new address</Link>
      </div>
      <div>
        <div className={styles.row}>
          <div className={styles.column}>Address1</div>
          <div className={styles.column}>Address2</div>
          <div className={styles.column}>City</div>
          <div className={styles.column}>State</div>
          <div className={styles.column}>Zip</div>
          <div className={styles.column}>IsDefault</div>
        </div>
        {props.addresses.map((address) => (
          <div className={styles.row} key={address.addressId}>
            <div className={styles.column}> {address.address1} </div>
            <div className={styles.column}> {address.address2} </div>
            <div className={styles.column}> {address.city} </div>
            <div className={styles.column}> {address.state} </div>
            <div className={styles.column}> {address.postalCode} </div>
            <div className={styles.column}> {address.isDefault} </div>
          </div>
        ))}
      </div>
    </>
  );
}
