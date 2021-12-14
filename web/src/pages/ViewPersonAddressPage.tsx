import AddressTable from "components/AddressTable";
import Gutter from "components/Gutter";
import LoadingSpinner from "components/LoadingSpinner";
import { Body, HeaderTwo } from "components/Typography";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { AddressListDto } from "server/AddressListDto";
import { AddressUrlWithPerson } from "server/EndPoints";
import { LoadState } from "server/LoadState";

type Props = {};

export default function ViewPersonAddressPage(props: Props) {
  const { personId } = useParams();
  const [loadState, setLoadState] = useState<LoadState>(LoadState.Loading);
  const [addressList, setAddressList] = useState<AddressListDto | null>();

  useEffect(() => {
    fetch(AddressUrlWithPerson(personId ?? ""))
      .then((response) =>
        response.json().then((data) => {
          setLoadState(LoadState.Complete);
          setAddressList(data);
        })
      )
      .catch(() => setLoadState(LoadState.Error));
  }, [personId]);

  const renderSwitch = (): React.ReactNode => {
    switch (loadState) {
      case LoadState.Complete:
        if (addressList == null) {
          return null;
        }

        return (
          <>
            <HeaderTwo>
              {addressList.personFirstName} has {addressList.addresses.length}{" "}
              addresses.
            </HeaderTwo>
            <AddressTable
              addresses={addressList.addresses}
              personId={addressList.personId}
            />
          </>
        );
      case LoadState.Error:
        return <Body>An Error has occurred</Body>;

      case LoadState.None:
      case LoadState.Loading:
        return <LoadingSpinner />;
    }
  };

  return <Gutter>{renderSwitch()}</Gutter>;
}
