import styles from './CurrencyTransfer.module.scss'
import { Header } from './Header/Header';
import { TableTranslation } from './TableTranslation/TableTranslation';

type CurrencyTransferProps = {
    infoHeader: {
        fromText: string;
        toText: string;
        dateText: string;
    };
    infoCurrencies: Array<{
        id: number;
        value: string;
        currency: string;
    }>;
}

export const CurrencyTransfer = (props: CurrencyTransferProps) => {
    return (
        <div className={styles.container}>
            <Header
                fromText={props.infoHeader.fromText}
                toText={props.infoHeader.toText}
                dateText={props.infoHeader.dateText}
            />
            <TableTranslation currencies={props.infoCurrencies} />
        </div>
    );
};