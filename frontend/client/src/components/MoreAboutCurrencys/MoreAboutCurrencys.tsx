import { ButtonMore } from './ButtonMore/ButtonMore';
import { InformationAboutCurrencys } from './InformationAboutCurrencys/InformationAboutCurrencys';
import styles from './MoreAboutCurrencys.module.scss';

type MoreAboutCurrencysProps = {
    currenciesData: Array<{
        id: number;
        title: string;
        description: string;
    }>;
}

export const MoreAboutCurrencys = (props: MoreAboutCurrencysProps) => {
    return (
        <div className={styles.information}>
            <ButtonMore />
            <InformationAboutCurrencys currencies={props.currenciesData} />
        </div>
    );
};